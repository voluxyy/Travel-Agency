using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentService(ICommentRepository repository)
        {
            this.commentRepository = repository;
        }

        public async Task<CommentDto> Add(CommentDto dto)
        {
            Comment comment = DtoToModel(dto);
            await commentRepository.Add(comment);
            CommentDto commentDto = ModelToDto(comment);

            return commentDto;
        }

        public async Task<CommentDto> Update(CommentDto dto)
        {
            Comment comment = DtoToModel(dto);
            await commentRepository.Update(comment);
            CommentDto commentDto = ModelToDto(comment);

            return commentDto;
        }

        public async Task<int> Delete(int id)
        {
            return await commentRepository.Delete(id);
        }

        public async Task<CommentDto> Get(int id)
        {
            return ModelToDto(await commentRepository.Get(id));
        }

        public List<CommentDto> GetAll()
        {
            List<Comment> comments = commentRepository.GetAll();
            List<CommentDto> commentsDtos = ListModelToDto(comments);

            return commentsDtos;
        }

        private CommentDto ModelToDto(Comment comment)
        {
            CommentDto commentDto = new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                UserId = comment.UserId,
                DestinationId = comment.DestinationId
            };

            return commentDto;
        }

        private Comment DtoToModel(CommentDto commentDto)
        {
            Comment comment = new Comment
            {
                Id = commentDto.Id,
                Text = commentDto.Text,
                UserId = commentDto.UserId,
                DestinationId = commentDto.DestinationId
            };

            return comment;
        }

        private List<CommentDto> ListModelToDto(List<Comment> destinations)
        {
            List<CommentDto> commentsDtos = new List<CommentDto>();

            foreach (Comment dest in destinations)
            {
                commentsDtos.Add(ModelToDto(dest));
            }
            return commentsDtos;
        }
    }
}
