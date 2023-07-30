using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Layers.Bussiness.DtoMappers.CommentMapper;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Repositories;
using Blog.Layers.Repositories.CommentRepository;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.Services.CommentService
{
    public class CommentService: ICommentService
    {
        private readonly ICommentMapper _commentMapper;
        private readonly IEntryRepository _entryRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentMapper commentMapper, IEntryRepository entryRepository/*, IUserRepository userRepository, ICommentRepository commentRepository*/)
        {
            _commentMapper = commentMapper;
            _entryRepository = entryRepository;
            //_userRepository = userRepository;
            //_commentRepository = commentRepository;
        }

        public string PostCommentByEntryId(CommentByEntryIdDto dto)
        {
            throw new NotImplementedException();
        }

        //public string PostCommentByEntryId(CommentByEntryIdDto dto)
        //{
        //    if (dto.EntryId == null || dto.UserId == null)
        //    {
        //        return "Entry Or User Null";
        //    }
        //    else
        //    {
        //        var entry = _entryRepository.GetById(dto.EntryId);
        //        if (entry == null)
        //        {
        //            return "Böyle Bir Entry Bulunmamaktadır.";
        //        }

        //        var user = _userRepository.GetById(dto.UserId);
        //        if (user == null)
        //        {
        //            return "Böyle Bir Kullanıcı Bulunmamaktadır.";
        //        }
        //        else
        //        {
        //            try
        //            {
        //                var comment = _commentMapper.CommentByEntryDtoTo(dto, entry, user);
        //                _commentRepository.Add(comment);
        //                return "İşlem Başarılı";
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e);
        //                return "İşlem Hatası!";
        //            }

        //        }
        //    }


    }
    }
