using Android.Content;
using Android.Content.Res;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Platforms.Android
{
    public class CustomShellRender: ShellRenderer
    {
        public CustomShellRender(Context context): base(context)
        {
            
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomShellBottomNavViewAppearanceTracker();    
        }
    }

    public class CustomShellBottomNavViewAppearanceTracker : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
            throw new NotImplementedException();
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
            bottomView.ItemIconSize = 30;
            bottomView.SetBackgroundColor(Color.FromRgb(31, 34, 37).ToPlatform());
            bottomView.ItemIconTintList = ColorStateList.ValueOf(Colors.LightGray.ToPlatform());
            bottomView.ItemActiveIndicatorColor = ColorStateList.ValueOf(Colors.Orange.ToPlatform());
          

        }
    }
}
