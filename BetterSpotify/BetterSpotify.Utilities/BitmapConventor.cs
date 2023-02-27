using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BetterSpotify.Utilities
{
    public class BitmapConventor
    {

        public static Bitmap MakeBitmap(string path)
        {
            try
            {
                Bitmap bm = new Bitmap(path);
                return bm;
            }
            catch
            {
                Console.WriteLine("Wrong path of file");
            }
            return null;
        }

    }
}
