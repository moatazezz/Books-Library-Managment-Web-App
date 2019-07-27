using AutoMapper;
using BLL.VM;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mapping
{
  public  class Mapping  :IMapping
    {
      public  IMapper iMapper { get; set; }
       public  Mapping()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Books, BooksVM>().ReverseMap();
                //cfg.CreateMap<BooksVM, Books>();
                
                cfg.CreateMap<CategoriesVM, Categories>().ReverseMap();
                //cfg.CreateMap<Categories, CategoriesVM>();
                cfg.CreateMap<BorrowTypeVM, BorrowType>().ReverseMap();
                cfg.CreateMap<BorrowReturnActionVM, BorrowReturnAction>().ReverseMap();
                cfg.CreateMap<BorrowersVM, Borrowers>().ReverseMap();
            });

            iMapper = config.CreateMapper();
        }
    }
}
