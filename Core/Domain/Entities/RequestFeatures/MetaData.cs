namespace Domain.Entities.RequestFeatures
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1; // currentPage 1'den büyükse kendisinden önce sayfa var,küçükse false
        public bool HasNextPage => CurrentPage < TotalPage; // mevcut sayfa toplam sayfa sayısından küçükse true; 
    }
}
