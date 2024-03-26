using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;

namespace DemoXAFBlazorForm.Blazor.Server.Extension
{
    public static class ViewExtension
    {
        public static void ShowDetailViewDialog(this XafApplication app, IObjectSpace os, string detailViewId, object item, Action okMethod,
    Action cancelMethod, ViewEditMode editMode = ViewEditMode.Edit,
    List<Controller> controllers = null, string okCaption = null, string cancelCaption = null,
    bool okActionVisible = true, bool cancelActionVisible = true, string? captionDetailView = null, bool isRoot = false)
        {
            os = os ?? app.CreateObjectSpace();
            DetailView dv = app.CreateDetailView(os, detailViewId, isRoot, item);
            if (!string.IsNullOrEmpty(captionDetailView))
                dv.Caption = captionDetailView;
            dv.ViewEditMode = editMode;
            ShowViewParameters svp = new ShowViewParameters();
            svp.CreatedView = dv;
            DialogController dc = app.CreateController<DialogController>();
            dc.AcceptAction.Caption = okCaption;
            dc.CancelAction.Caption = cancelCaption;
            dc.Accepting += (sender, args) =>
            {
                okMethod?.Invoke();
            };
            dc.Cancelling += (sender, args) =>
            {
                cancelMethod?.Invoke();
            };
            dc.SaveOnAccept = false;

            svp.Controllers.Add(dc);
            if (controllers != null && controllers.Any())
                svp.Controllers.AddRange(controllers);

            if (!string.IsNullOrEmpty(okCaption))
                dc.AcceptAction.Caption = okCaption;

            if (!string.IsNullOrEmpty(cancelCaption))
                dc.CancelAction.Caption = cancelCaption;


            if (!okActionVisible)
                dc.AcceptAction.Active["ShowDetailViewDialog"] = false;

            if (!cancelActionVisible)
                dc.CancelAction.Active["ShowDetailViewDialog"] = false;


            svp.Context = TemplateContext.PopupWindow;
            svp.TargetWindow = TargetWindow.NewModalWindow;
            svp.NewWindowTarget = NewWindowTarget.Separate;

            app.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));

        }
    }
}
