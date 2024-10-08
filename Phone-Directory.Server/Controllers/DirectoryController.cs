﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Directory.Business.Abstract;
using Phone_Directory.Constants;
using Phone_Directory.Entities.DTOS.Directory;

namespace Phone_Directory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;
        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet("getDirectoriesByUserId")]
        public async Task<IActionResult> GetDirectoriesByUserId(int userId)
        {
            var directories = await _directoryService.GetDirectoriesByUserIdAsync(userId);
            if (directories == null)
            {
                return NotFound();
            }
            return Ok(new { Data = directories, Message = Messages.UserSpecificRecords });
        }

        [HttpGet("getDirectoryById")]
        public async Task<IActionResult> GetDirectoryById(int id)
        {
            var directory = await _directoryService.GetDirectoryByIdAsync(id);
            if (directory == null)
            {
                return NotFound(new { Message = Messages.NotRecordFound });
            }
            return Ok(new { Data = directory, Message = Messages.RecordBrought });
        }

        [HttpPost("addDirectory")]
        public async Task<IActionResult> AddDirectory([FromBody] AddDirectoryDto addDirectoryDto)
        {
            var newDirectory = await _directoryService.AddDirectoryAsync(addDirectoryDto);

            return Ok(new { Data = newDirectory, Message = Messages.RecordAddedDirectory });
        }

        [HttpPut("updateDirectory")]
        public async Task<IActionResult> UpdateDirectory([FromBody] UpdateDirectoryDto updateDirectoryDto)
        {
            var updatedDirectory = await _directoryService.UpdateDirectoryAsync(updateDirectoryDto);

            return Ok(new { Data = updatedDirectory, Message = Messages.RecordUpdatedDirectory });
        }

        [HttpDelete("deleteDirectory")]
        public async Task<IActionResult> DeleteDirectory(int id)
        {
            await _directoryService.DeleteDirectoryAsync(id);

            return Ok(new { Message = Messages.RecordDeletedDirectory });
        }
    }
}
