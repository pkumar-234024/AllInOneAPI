using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.Core.Services;
public class AiToolService : IAiToolService
{
  private readonly IRepository<AiToolModel> _aiToolModelRepository;
  public AiToolService(IRepository<AiToolModel> aiToolModelRepository)
  {
    _aiToolModelRepository = aiToolModelRepository;
  }

  public async Task<AiToolDtoOutWithId> CreateAiTool(AiToolCreateDto createDto)
  {
    try
    {
      var model = new AiToolModel
      {
        Name = createDto.Name,
        Description = createDto.Description,
        Image = createDto.Image,
        ImagePath = createDto.ImagePath,
        ToolUrl = createDto.ToolUrl
      };

      await _aiToolModelRepository.AddAsync(model);

      return new AiToolDtoOutWithId
      {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Image = model.Image,
        ImagePath = model.ImagePath,
        ToolUrl = model.ToolUrl
      };
    }
    catch (Exception ex)
    {
      throw new Exception($"{ex.Message} \n {ex.StackTrace} ");
    }
  }

  public async Task<int> DeleteAiToolById(AiToolDeleteDto deleteDto)
  {
    try
    {
      var model = await _aiToolModelRepository.GetByIdAsync(deleteDto.Id);
      if (model == null)
        throw new Exception($"AiTool with Id {deleteDto.Id} not found.");

      await _aiToolModelRepository.DeleteAsync(model);
      return deleteDto.Id;
    }
    catch (Exception ex)
    {
      throw new Exception($"{ex.Message} \n {ex.StackTrace} ");
    }
  }

  public async Task<AiToolDtoOutWithId> GetAiToolById(int id)
  {
    try
    {
      var model = await _aiToolModelRepository.GetByIdAsync(id);
      if (model == null)
        throw new Exception($"AiTool with Id {id} not found.");

      return new AiToolDtoOutWithId
      {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Image = model.Image,
        ImagePath = model.ImagePath,
        ToolUrl = model.ToolUrl
      };
    }
    catch (Exception ex)
    {
      throw new Exception($"{ex.Message} \n {ex.StackTrace} ");
    }
  }

  public async Task<List<AiToolDtoOutWithId>> GetAiToolList()
  {
    try
    {
      var models = await _aiToolModelRepository.ListAsync();
      return models.Select(model => new AiToolDtoOutWithId
      {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Image = model.Image,
        ImagePath = model.ImagePath,
        ToolUrl = model.ToolUrl
      }).ToList();
    }
    catch (Exception ex)
    {
      throw new Exception($"{ex.Message} \n {ex.StackTrace} ");
    }
  }

  public async Task<AiToolDtoOutWithId> UpdateAiToolById(AiToolUpdateDto updateDto)
  {
    try
    {
      var model = await _aiToolModelRepository.GetByIdAsync(updateDto.Id);
      if (model == null)
        throw new Exception($"AiTool with Id {updateDto.Id} not found.");

      model.Name = updateDto.Name;
      model.Description = updateDto.Description;
      model.Image = updateDto.Image;
      model.ImagePath = updateDto.ImagePath;
      model.ToolUrl = updateDto.ToolUrl;

      await _aiToolModelRepository.UpdateAsync(model);

      return new AiToolDtoOutWithId
      {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Image = model.Image,
        ImagePath = model.ImagePath,
        ToolUrl = model.ToolUrl
      };
    }
    catch(Exception ex) {
      throw new Exception($"{ex.Message} \n {ex.StackTrace} ");
    }
  }
}
