using DemoXAFBlazorForm.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using Microsoft.AspNetCore.Components;

namespace DemoXAFBlazorForm.Blazor.Server.Editors
{
    public partial class SelectActivityComponent: ComponentBase
    {
        [Inject] IObjectSpaceFactory objectSpaceFactory {  get; set; }
        IObjectSpace objectSpace { get; set; }
        private Activity Activity { get; set; }

        protected override void OnInitialized()
        {
            
            objectSpace = objectSpaceFactory.CreateObjectSpace(typeof(ActivityNonPersistent));
            
        }

        public void AddActivity() 
        {
            ActivityNonPersistent activityNonPersistent = objectSpace.CreateObject<ActivityNonPersistent>();
            activityNonPersistent.Start = ComponentModel.Value.Start;
            activityNonPersistent.End = ComponentModel.Value.End;
            activityNonPersistent.Causal = ComponentModel.Value.Causal;
            activityNonPersistent.Assignees = ComponentModel.Value.Assignees;
            activityNonPersistent.Balance = ComponentModel.Value.Balance;
            ComponentModel.Value.ActivityNonPersistents.Add(activityNonPersistent);
            StateHasChanged();
        }
    }
}
