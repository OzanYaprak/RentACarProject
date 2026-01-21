using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Repositories;

public interface IBrandRepository: IAsyncRepository<Brand>, IRepository<Brand>
{
}
