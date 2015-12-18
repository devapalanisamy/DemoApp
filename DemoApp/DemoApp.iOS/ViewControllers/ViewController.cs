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



			QualificationTable.Delegate = new QualificationDelegate (Results);

		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			var restservice = new RestService ();
			Results = await restservice.RefreshDataAsync ();
			QualificationTable.RowHeight = 50;
			QualificationTable.Source = new QualificationDataSource (Results);
			QualificationTable.ReloadData();
		}

		public class QualificationDataSource: UITableViewSource
		{
			public List<Qualification> Items;
			public QualificationDataSource(List<Qualification> items)
			{
				Items = items;
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
				//cell.TextLabel.Text = indexPath.Row.ToString();
				return cell;
			}
			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return Items.Count;
			}
		}

		public class QualificationDelegate: UITableViewDelegate
		{
			public QualificationDelegate(List<Qualification> items)
			{
				Items = items;
			}

			public List<Qualification> Items { get; set; }
			public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				SubjectsViewController SubjectsViewController = new SubjectsViewController (){ Subjects = Items [indexPath.Row].subjects };

			}
		}
	}
}

