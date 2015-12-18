using System;

using UIKit;
using DemoApp.Core;
using System.Collections.Generic;

namespace DemoApp.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public List<Qualification> Results;

		public  override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			var restservice = new RestService ();
			Results = await restservice.RefreshDataAsync ();
			QualificationTable.RowHeight = 50;
			QualificationTable.Source = new QualificationDataSource (Results,this);
			QualificationTable.ReloadData();
		}

		public class QualificationDataSource: UITableViewSource
		{
			public List<Qualification> Items;
			public ViewController Viewcontroller1;
			public QualificationDataSource(List<Qualification> items, ViewController viewcontroller)
			{
				Items = items;
				Viewcontroller1 = viewcontroller;
			}

			public QualificationDataSource()
			{
			}

			string CellIdentifier = "TableCell";

			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);

				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
				}
				cell.TextLabel.Text = Items [indexPath.Row].name;
				return cell;
			}
			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return Items.Count;
			}

			public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				SubjectsViewController SubjectsViewController = new SubjectsViewController (){ Subjects = Items [indexPath.Row].subjects };
				Viewcontroller1.NavigationController.PushViewController (SubjectsViewController, true);
			}
		}

	}
}

