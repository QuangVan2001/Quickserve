using System.Collections.Generic;
using System.Data.Common;

namespace QuickServe.Application.DTOs
{
    public class PagenationResponseDto<T>
    {
        public PagenationResponseDto(List<T> data, int count)
        {
            Data = data;
            Count = count;
        }
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }

    public class PagenationsReponseDTO<T>
    {
        public PagenationsReponseDTO(List<T> data, int count)
        {
            Data = data;
            Count = count;
        }
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}
