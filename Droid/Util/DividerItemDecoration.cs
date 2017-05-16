
using Android.App;
using Android.Content;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Support.V4.Content;
using Android.Graphics;

namespace PicTalk.Droid.Util
{
    [Activity(Label = "DividerItemDecoration")]
    public class DividerItemDecoration : RecyclerView.ItemDecoration
    {
        private static int[] ATTRS = new int[] { Android.Resource.Attribute.ListDivider };

        private Drawable divider;

        public DividerItemDecoration(Context context)
        {
            TypedArray styledAttributes = context.ObtainStyledAttributes(ATTRS);
            divider = styledAttributes.GetDrawable(0);
            styledAttributes.Recycle();
        }

        public DividerItemDecoration(Context context, int resId)
        {
            divider = ContextCompat.GetDrawable(context, resId);
        }


        public override void OnDrawOver(Canvas c, RecyclerView parent, RecyclerView.State state)
        {
            int left = parent.PaddingLeft;
            int right = parent.Width - parent.PaddingRight;

            int childCount = parent.ChildCount;
            for (int i = 0; i < childCount-1; i++)
            {
                View child = parent.GetChildAt(i);

                ViewGroup.MarginLayoutParams parameters = (ViewGroup.MarginLayoutParams)child.LayoutParameters;

                int top = child.Bottom + parameters.BottomMargin;
                int bottom = top + divider.IntrinsicHeight;

                divider.SetBounds(left, top, right, bottom);
                divider.Draw(c);
            }
        }
    }
}