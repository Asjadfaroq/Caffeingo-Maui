using CommunityToolkit.Mvvm.ComponentModel;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.MVVM.Models
{
    public partial class Coffee : ObservableObject
    {
        public String Name { get; set; }
        public String SubTitle { get; set; }
        public String Image { get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => Price * CartQuantity;

        public Coffee Clone() => MemberwiseClone() as Coffee;
    }

}
