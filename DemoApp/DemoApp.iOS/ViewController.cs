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

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//var restservice = new RestService ();
			//var Result = await restservice.RefreshDataAsync ();



			//QualificationTable.Delegate = new QualificationDelegate ();
			QualificationTable.DataSource = new QualificationDataSource ();
		}

		public class QualificationDataSource: UITableViewDataSource
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
				//cell.TextLabel.Text = Items [indexPath.Row].name;
				cell.TextLabel.Text = indexPath.Row.ToString();
				return cell;
			}
			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return 10;
			}
		}
	}
}

