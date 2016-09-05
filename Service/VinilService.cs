using Data_Access_Layer;
using Data_Access_Layer.UnitOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   static public class VinilService
    {
        static public List<Vinil> GetAll()
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return new List<Vinil>(uow.Vinils.GetAllVinils());
            }
            
        }
        static public Dictionary<string,int> GetAllArtist()
        {
            var col =  GetAll();
            var artists = new Dictionary<string,int>();
            foreach(var item in col)
            {
                if (!artists.ContainsKey(item.Artist))
                    artists.Add(item.Artist, 1);
                else artists[item.Artist]++;
            }
            return artists;
        }
        static public Dictionary<string, int> GetAllStyle()
        {
            var col = GetAll();
            var style = new Dictionary<string, int>();
            foreach (var item in col)
            {
                if (!style.ContainsKey(item.Styles))
                    style.Add(item.Styles, 1);
                else style[item.Styles]++;
            }
            return style;
        }
        static public Dictionary<string, int> GetAllAlbum()
        {
            var col = GetAll();
            var album = new Dictionary<string, int>();
            foreach (var item in col)
            {
                if (!album.ContainsKey(item.Album))
                    album.Add(item.Album, 1);
                else album[item.Album]++;
            }
            return album;
        }
        static public int GetVinilsMaxPrise()
        {
            return (int)GetAll().Max(vinil => vinil.Price);
        }
        static public List<Vinil> GetCountOfVinils(List<Vinil> col,int last = 0, int count = 10)
        {
            return new List<Vinil>(col.Skip(last).Take(count));
        }
        
        static public List<Vinil> PagenatorNext(int count, int pageNumber,List<Vinil> col )
        {
            return GetCountOfVinils(col, count *( pageNumber-1), count);
        }
        static public List<Vinil> PagenatorNext(int count, int pageNumber)
        {
            var col = GetAll();
            return GetCountOfVinils(col, count * (pageNumber-1), count);
        }

        static public int GetVinilsMaxPrise(List<Vinil> col)
        {
            return (int)col.Max(vinil => vinil.Price);
        }
        static public int GetVinilsMinPrise()
        {
            return (int)GetAll().Min(vinil => vinil.Price);
        }
        static public int GetVinilsMinPrise(List<Vinil> col)
        {
            return (int)col.Min(vinil => vinil.Price);
        }
        static public List<Vinil> GetAllVinilsByPrise(int firstrange, int secondrange, IReadOnlyCollection<Vinil> col)
        {
            return new List<Vinil>(col.Where(vinil => vinil.Price <= secondrange && vinil.Price >= firstrange));

        }
        static public List<Vinil> GetAllVinilsByArtist(string artist, List<Vinil> col)
        {
            return new List<Vinil>(col.Where(vinil => vinil.Artist == artist));
        }
        static public List<Vinil> GetAllVinilsByAlbum(string album, List<Vinil> alb)
        {
            return new List<Vinil>(alb.Where(vinil => vinil.Album == album));
        }
        static public List<Vinil> GetAllVinilsByStyle(string style, List<Vinil> col)
        {
            return new List<Vinil>(col.Where(vinil => vinil.Styles == style));
        }
        static public List<Vinil> SortUp(List<Vinil> col)
        {
            return new List<Vinil>(col.OrderBy(vinil => vinil.Price));
        }
        static public List<Vinil> SortDown(List<Vinil> col)
        {
            return new List<Vinil>(col.OrderByDescending(vinil => vinil.Price));
        }
        static public List<Vinil> GetVinilsBySettings(int priseMin, int priseMax, string[] style, string[] artist, string[] album, string sort,int count, int page)
        {
            
            var col = new List<Vinil>();
            var col2 = new List<Vinil>();
            var col3 = new List<Vinil>();
            if (style[0] != "") foreach (var item in style)
                {
                    col = col.Concat(GetAllVinilsByStyle(item, GetAll())).ToList();
                }
            else col = GetAll();
            if (artist[0] != "") foreach (var item in artist)
                {
                    col2 =col2.Concat(GetAllVinilsByArtist(item, col)).ToList();
                }
            else col2 = col;
            if (album[0] != "")
                foreach (var item in album)
                {
                    col3 = col3.Concat(GetAllVinilsByAlbum(item, col2)).ToList();
                }
            else col3 = col2;
            col3 = GetAllVinilsByPrise(priseMin, priseMax, col3);
            if(sort == "Возрастание")
            {
                col3 = SortUp(col3);
            }
            else if(sort == "Убывание")
            {
                col3 = SortDown(col3);
            }
            return PagenatorNext(count,page, col3);
             
        }
        static public void Add(Vinil vinil)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                uow.Vinils.Add(vinil);
                uow.Save();
            }
        }
    }
}
