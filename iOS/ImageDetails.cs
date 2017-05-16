using System;
using CoreGraphics;
using UIKit;
namespace PicTalk.iOS
{
	public class ImageDetails
	{

		public float Height { get; set; }

		public string Name { get; set; }

		public float Width { get; set; }

		public CGSize Size
		{
			get
			{
				return new CGSize(Width, Height);
			}
		}
	}
}
