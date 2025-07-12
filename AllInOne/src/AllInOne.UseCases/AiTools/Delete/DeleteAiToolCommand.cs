using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Shared.InputDTO;

namespace AllInOne.UseCases.AiTools.Delete;
public record DeleteAiToolCommand(AiToolDeleteDto aiToolDeleteDto) : ICommand<Result<int>>;
