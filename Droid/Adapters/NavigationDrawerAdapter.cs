using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using PicTalk.Droid.Models;
using PicTalk.Droid.ViewHolder;

namespace PicTalk.Droid.Adapters
{
    [Activity(Label = "NavigationDrawerAdapter")]
    class NavDrawer : RecyclerView.Adapter
    {
        List<NavigationCatagoriesList> MainMenu;
        private LayoutInflater inflater;
        private Context context;


        public NavDrawer(Context context, List<NavigationCatagoriesList> MainMenu)
        {
            this.context = context;
            this.MainMenu = MainMenu;
            inflater = LayoutInflater.From(context);
        }

        public override int ItemCount
        {
            get
            {
                return MainMenu.Count;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = inflater.Inflate(Resource.Layout.nav_catagory_items_list, parent, false);
            MyViewHolder mHolder = new MyViewHolder(view);
            return mHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            MyViewHolder mViewHolder = holder as MyViewHolder;
            //mViewHolder.txtCount.Text = ( position + 1 ).ToString();
            mViewHolder.txtTitle.Text = MainMenu[position].CatagoryName;
            mViewHolder.Icon.SetImageResource(Resource.Mipmap.ic_arrow_forward);
        }
                
        }
    }
