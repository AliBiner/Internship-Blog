using System;
using Blog.Layers.Bussiness.DtoMappers.CommentMapper;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Repositories;
using Blog.Layers.Repositories.CommentRepository;

namespace Blog.Layers.Bussiness.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentMapper _commentMapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(IUserRepository userRepository, IEntryRepository entryRepository,
            ICommentMapper commentMapper, ICommentRepository commentRepository)
        {
            _userRepository = userRepository;
            _entryRepository = entryRepository;
            _commentMapper = commentMapper;
            _commentRepository = commentRepository;
        }

        public string PostCommentByEntryId(CommentByEntryIdDto dto)
        {
            if (dto.EntryId == null || dto.UserId == null)
                return "Entry Or User Null";
            try
            {
                var comment = _commentMapper.CommentByEntryDtoTo(dto);
                _commentRepository.Add(comment);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası!";
            }
        }
    }
}