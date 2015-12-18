using System;

using UIKit;
using DemoApp.Core;
using System.Collections.Generic;

namespace DemoApp.iOS
{
	public partial class SubjectsViewController : UIViewController
	{
		public SubjectsViewController () : base ("SubjectsViewController", null)
		{
		}

		public List<Subject> Subjects { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			SubjectsTableView.RowHeight = 50;
			SubjectsTableView.Source = new SubjectsSource (Subjects);
			SubjectsTableView.ReloadData();
		}

		public class SubjectsSource: UITableViewSource
		{
			public List<Subject> Items;
			public SubjectsSource(List<Subject> items)
			{
				Items = items;
			}

			public SubjectsSource()
			{
			}

			string CellIdentifier = "TableCell";

			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);

				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
				}
				cell.TextLabel.Text = Items [indexPath.Row].title;
				if(Items [indexPath.Row].colour != null)
					cell.TextLabel.TextColor = UIColorExtensions.FromHexString (Items [indexPath.Row].colour, 1.0f);
				return cell;
			}
			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return Items.Count;
			}
		}
	}
}


