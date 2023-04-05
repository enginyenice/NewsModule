using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsModule.Business.Exceptions;
using NewsModule.Business.Interfaces;
using NewsModule.DataAccess.Repositories.Interfaces;
using NewsModule.DataAccess.UnitOfWorks;
using NewsModule.DTOs.NewsDtos;
using NewsModule.Entities.Models;

namespace NewsModule.Business.Concreates
{
    public class NewsManager : INewsService
    {
        private readonly IGenericRepository<News> _newsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsManager(IGenericRepository<News> newsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetNewsDto> Create(NewsDto newsDto)
        {
            News news = _mapper.Map<News>(newsDto);
            _newsRepository.Add(news);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result == 0) throw new BusinessException("Haber kayıt edilemedi");
            return _mapper.Map<GetNewsDto>(news);
        }

        public async Task<bool> Delete(int id)
        {
            var news = await _newsRepository.GetByIdAsync(id);
            _newsRepository.Delete(news);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == 0) throw new BusinessException("Haber silinemedi");
            return true;
        }

        public async Task<List<GetNewsDto>> GetAll()
        {
            var news = await _newsRepository.Query().ToListAsync();
            var getNewsDtoList = _mapper.Map<List<GetNewsDto>>(news);
            return getNewsDtoList;
        }

        public async Task<GetNewsDto> GetById(int id)
        {
            var news = await _newsRepository.GetByIdAsync(id);
            if(news == null) throw new BusinessException("Haber bulunamadı");
            return _mapper.Map<GetNewsDto>(news);
        }

        public async Task<GetNewsDto> Update(int id, NewsDto newsDto)
        {
            var news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new BusinessException("Haber bulunamadı");
            news.Title = newsDto.Title;
            news.Description = newsDto.Description;
            _newsRepository.Update(news);

            var result = await _unitOfWork.SaveChangesAsync();
            if (result == 0) throw new BusinessException("Haber güncellenemedi");
            return _mapper.Map<GetNewsDto>(news);
        }
    }
}
