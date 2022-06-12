using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementWithLinq
{
    class ProductReview
    {
        public int ProducID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool isLike { get; set; }
    }


}
