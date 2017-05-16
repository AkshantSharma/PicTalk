using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Support.V7.Widget;
using System;
using PicTalk.Droid.Models;
using PicTalk.Droid.Helper;
using Com.Bumptech.Glide;
using PicTalk.Models.ModelResponses;
using Android.Content.Res;
using Android.Support.V4.Content.Res;
using Java.Lang;
using Android.Graphics;

namespace PicTalk.Droid.Adapters
{
    [Activity(Label = "CategoryListAdapter")]
    public class CategoryListAdapter : RecyclerView.Adapter
    {
        #region Private\public Members
        List<MoviesModelResponse> CategoryList;
        private LayoutInflater inflater;
        public Context context;

        //Allocating a Event handler for "ITEM CLICK" on adapter
        public event EventHandler<int> ItemClick;
        #endregion

        public CategoryListAdapter(Context context,List<MoviesModelResponse> CategoryList)
        {
            this.context = context;
            this.CategoryList = CategoryList;
            inflater = LayoutInflater.From(context);
        }
        public override int ItemCount
        {
            get
            {
                return CategoryList.Count;
            }
        }
        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = inflater.Inflate(Resource.Layout.category_card_view, parent, false);
            ViewHolder.CategoryListViewHolder mHolder = 
                new ViewHolder.CategoryListViewHolder(this.context,view,OnClick);
            return mHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PicTalk.Utils.Utility utils = new PicTalk.Utils.Utility();
            ViewHolder.CategoryListViewHolder CategoryViewHolder = holder as ViewHolder.CategoryListViewHolder;
            Random rand = new Random();
            int a = rand.Next(1, 3);
            


            switch (a)
            {
                case 1:
                    Glide.With(context)
                         .Load(Resource.Mipmap.a)
                         .Placeholder(Resource.Mipmap.myplaceholder)
              .Into(CategoryViewHolder.Imageone);
                    Glide.With(context)
                         .Load(Resource.Mipmap.b)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagetwo);
                    Glide.With(context)
                         .Load(Resource.Mipmap.c)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagethree);

                    break;
                case 2:
                    Glide.With(context)
                         .Load(Resource.Mipmap.d)
                         .Placeholder(Resource.Mipmap.myplaceholder)
              .Into(CategoryViewHolder.Imageone);
                    Glide.With(context)
                         .Load(Resource.Mipmap.e)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagetwo);
                    Glide.With(context)
                         .Load(Resource.Mipmap.f)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagethree);

                    break;
                case 3:
                    Glide.With(context)
                         .Load(Resource.Mipmap.g)
                         .Placeholder(Resource.Mipmap.myplaceholder)
              .Into(CategoryViewHolder.Imageone);
                    Glide.With(context)
                         .Load(Resource.Mipmap.h)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagetwo);
                    Glide.With(context)
                         .Load(Resource.Mipmap.i)
                         .Placeholder(Resource.Mipmap.myplaceholder)
                        .Into(CategoryViewHolder.Imagethree);
                    break;
            }
            CategoryViewHolder.TextMovieName.Text = CategoryList[position].Name;
            CategoryViewHolder.TextMovieName.SetTextSize(Android.Util.ComplexUnitType.Dip, utils.TextSizeHeader);
            CategoryViewHolder.TextDate.Text = CategoryList[position].Release.ToString("D");
            CategoryViewHolder.TextDate.SetTextSize(Android.Util.ComplexUnitType.Dip, utils.TextSizeHeader);
        }
    }
}