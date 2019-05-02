
/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/

using Nile.Stores;
using Nile.Stores.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion
        private static String _connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=NileDatabase;Integrated Security=SSPI;";

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"];
            _database = new SqlDatabase(_connectionString);//connString.ConnectionString);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Handle errors
            while (true)
            {
                //Modal
                //if (child.ShowDialog(this) == DialogResult.OK)
                //    return;
                //Add
                try
                {
                //Anything in here that raises an exception will
                //be sent to the catch block
                    OnSafeAdd(child);
                    break;
                }
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };


            UpdateList();
        }

        /// <summary>
        /// safely add the Contact to the database
        /// </summary>
        /// <param name="form"></param>
        private void OnSafeAdd(ProductDetailForm form)
        {
            try
            {
                //Save product
                _database.Add(form.Product);
            }
            catch (Exception e)
            {
                //recover
                DisplayError(e);
            };
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Handle errors
            try
            {
                _database.Delete(product.Id);
            } catch (Exception ex)
            {
                //Recover
                DisplayError(ex);
            }


            //Update list
            
            UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            
            //Save product
            try
            {
                _database.Update(child.Product.Id, child.Product);
            } catch (Exception ex)
            {
                DisplayError(ex);
            }
            
            UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            //Handle errors
            try
            {
                _bsProducts.DataSource = _database.GetAll();
            } catch (Exception ex)
            {
                DisplayError(ex);
            }
            
        }

        private ProductDatabase _database = new SqlDatabase(_connectionString);
        #endregion

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var form = new AboutBox();

            form.ShowDialog();
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
