using DemoXAFBlazorForm.Blazor.Server.Extension;
using DemoXAFBlazorForm.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.Data.Utils;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraRichEdit.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DemoXAFBlazorForm.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SelectActivityController : ViewController
    {
        SimpleAction selectActivity;
        public SelectActivityController()
        {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Root;
            selectActivity = new SimpleAction(this, "selectActivity", PredefinedCategory.ObjectsCreation);
            selectActivity.Caption = "Select Activity";
            selectActivity.Execute += SelectActivity_Execute; ;
        }

        private void SelectActivity_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var nonPersistentOS = Application.CreateObjectSpace(typeof(SelectActivityNonPersistent));
            SelectActivityNonPersistent selectActivity = nonPersistentOS.CreateObject<SelectActivityNonPersistent>();
            selectActivity.ActivityNonPersistent = nonPersistentOS.CreateObject<ActivityNonPersistent>();
            DetailView detailView = Application.CreateDetailView(nonPersistentOS, selectActivity);
            Application.ShowDetailViewDialog(nonPersistentOS, detailView.Id, selectActivity, () =>
            {
                selectActivity.ActivityNonPersistent.ActivityNonPersistents.ForEach(a => 
                {
                    var activity = ObjectSpace.CreateObject<Activity>();
                    activity.Start = a.Start;
                    activity.End = a.End;
                    activity.Balance = a.Balance;
                    activity.Causal = a.Causal;
                    activity.CancellationReason = a.CancellationReason;
                });
                
                ObjectSpace.CommitChanges();
            }, null, ViewEditMode.Edit, null, "Save", "Cancel");
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
