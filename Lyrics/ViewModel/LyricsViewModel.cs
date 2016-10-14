using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lyrics.ViewModel
{
    public class LyricsViewModel
    {
        public IEnumerable<Models.LyricsCategoryTable> lyricsCategory { get; set; }
        public IEnumerable<Models.LyricsSubCategoryTable> lyricsSubCategory { get; set; }
        public IEnumerable<Models.lyricsTable> lyrics { get; set; }
    }
}