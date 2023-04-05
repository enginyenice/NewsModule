using NewsModule.DTOs.NewsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Interfaces
{
    public interface INewsService
    {
        Task<List<GetNewsDto>> GetAll();
        Task<GetNewsDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<GetNewsDto> Update(int id, NewsDto newsDto);
        Task<GetNewsDto> Create(NewsDto newsDto);
    }
}
