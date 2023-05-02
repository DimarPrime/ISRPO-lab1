using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WpfLab5
{
    public class Shop : INotifyPropertyChanged
    {
        int id;
        string product;
        int count;
        int price;
        int sum;
        int total;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Sum
        {
            get { return sum; }
            set
            {
                
                sum = value;
                                
                OnPropertyChanged("Sum");
            }
        }
         public int Total
         {
             get { return total; }
             set
             {

                 total = value;

                 OnPropertyChanged("Total");
             }
         }
       
     

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<Shop> Initialize()
        {
            return new ObservableCollection<Shop>()
            {
              new Shop
              {
                Id=1,
                Product="Арбузы",
                Count=3,
                Price=16,
                Sum=3*16,
               
                
                
                
               // Total=3*16
              },
              new Shop
              {
                Id=2,
                Product="Тыква",
                Count=10,
                Price=40,
                Sum=10*40,
                
                
               // Total=(3*16)+(10*40)
              },
              new Shop
              {
                Id=3,
                Product="Яблоки",
                Count=8,
                Price=80,
                Sum=8*80,
                
                
                //Total=(3*16)+(10*40)+(8*80)

              },
              new Shop
              {
                Id=4,
                Product="Лимоны",
                Count=35,
                Price=120,
                Sum=35*120,
                
              },
              new Shop
              {
                  Product="0",
               Total=(3*16)+(10*40)+(8*80)+(35*120)
              },


           };

        }
    }

}
