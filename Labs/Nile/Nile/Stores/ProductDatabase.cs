
/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/30/2019
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //Validate input
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //Game must be valid            
            //new ObjectValidator().Validate(game);
            Validator.ValidateObject(product, new ValidationContext(product));

            //Game names must be unique
            var existing = FindByName(product.Name);
            if (existing != null)
                throw new Exception("Game must be unique.");

            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
                    
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Delete ( int id )
        {
            //Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            DeleteCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( int id, Product product )
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //validate
            Validator.ValidateObject(product, new ValidationContext(product));

            var existing = GetCore(id);
            if (existing == null)
                throw new Exception("Game does not exist.");

            //Game names must be unique            
            var sameName = FindByName(product.Name);
            if (sameName != null && sameName.Id != id)
                throw new Exception("Game must be unique.");

            return UpdateCore(existing, product);
        }

        protected virtual Product FindByName(string name)
        {
            return (from product in GetAllCore()
                    where String.Compare(product.Name, name, true) == 0
                    orderby product.Name, product.Id descending
                    select product).FirstOrDefault();
        }


        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void DeleteCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
