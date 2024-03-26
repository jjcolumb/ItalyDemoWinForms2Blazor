using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DemoXAFBlazorForm.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Activity : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Activity(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        Data data;
        public Data Data
        {
            get => data;
            set => SetPropertyValue(nameof(Data), ref data, value);
        }
        DateTime start;
        public DateTime Start
        {
            get => start;
            set => SetPropertyValue(nameof(Start), ref start, value);
        }
        DateTime end;
        public DateTime End
        {
            get => end;
            set => SetPropertyValue(nameof(End), ref end, value);
        }
        Document document;
        public Document Document
        {
            get => document;
            set => SetPropertyValue(nameof(Document), ref document, value);
        }
        decimal balance;
        public decimal Balance
        {
            get => balance;
            set => SetPropertyValue(nameof(Balance), ref balance, value);
        }
        string cancellationReason;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CancellationReason
        {
            get => cancellationReason;
            set => SetPropertyValue(nameof(CancellationReason), ref cancellationReason, value);
        }
        string category;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }
        string causal;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Causal
        {
            get => causal;
            set => SetPropertyValue(nameof(Causal), ref causal, value);
        }
        string origin;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Origin
        {
            get => origin;
            set => SetPropertyValue(nameof(Origin), ref origin, value);
        }
        PaymentPlans paymentPlans;
        public PaymentPlans PaymentPlans
        {
            get => paymentPlans;
            set => SetPropertyValue(nameof(PaymentPlans), ref paymentPlans, value);
        }
        string _event;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Event
        {
            get => _event;
            set => SetPropertyValue(nameof(Event), ref _event, value);
        }
        Article article;
        public Article Article
        {
            get => article;
            set => SetPropertyValue(nameof(Article), ref article, value);
        }
        string assignees;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Assignees
        {
            get => assignees;
            set => SetPropertyValue(nameof(Assignees), ref assignees, value);
        }
        string instruments;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Instruments
        {
            get => instruments;
            set => SetPropertyValue(nameof(Instruments), ref instruments, value);
        }
    }
}