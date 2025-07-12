using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.Core.Interfaces;
public interface IAiToolService
{
  Task<AiToolDtoOutWithId> GetAiToolById(int id);
  Task<AiToolDtoOutWithId> CreateAiTool(AiToolCreateDto createDto);
  Task<List<AiToolDtoOutWithId>> GetAiToolList();
  Task<AiToolDtoOutWithId> UpdateAiToolById(AiToolUpdateDto id);
  Task<int> DeleteAiToolById(AiToolDeleteDto deleteDto);
}
