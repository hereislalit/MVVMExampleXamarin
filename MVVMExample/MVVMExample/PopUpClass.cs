using System;
using Xamarin.Forms;

namespace MVVMExample
{
    class PopUpClass
    {
        ContentPage rootPage;
        View baseView;
        RelativeLayout baseRelativeLayout;
        StackLayout popUpModelLayout;
        View popUpView;
        public PopUpClass(ContentPage page)
        {
            rootPage = page;
            baseView = page.Content;
            baseRelativeLayout = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            Button button = new Button
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "Hello this is Button",
            };
            button.Clicked += onButtonClicked;
            popUpView = button;
        }

        public void showPopup()
        {
            addPopUp();
        }
        private void addPopUp()
        {
            baseRelativeLayout.Children.Add(baseView, Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }));
            rootPage.Content = baseRelativeLayout;
            popUpModelLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            popUpModelLayout.Children.Add(popUpView);
            popUpModelLayout.BackgroundColor = Color.Red.MultiplyAlpha(0.3d);
            baseRelativeLayout.Children.Add(popUpModelLayout,
            xConstraint: Constraint.Constant(0),
            yConstraint: Constraint.Constant(0),
            widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
            heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
        }

        private void revertLayout()
        {
                baseRelativeLayout.Children.Remove(baseView);
                rootPage.Content = baseView;
        }

        public void setCustomView(View view) {
            popUpView = view;
        }

        private void onButtonClicked(object sender, EventArgs e)
        {
            hidePopUp();
        }

        public void hidePopUp()
        {
            revertLayout();
        }

    };
}
