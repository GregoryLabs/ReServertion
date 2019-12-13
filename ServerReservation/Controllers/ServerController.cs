using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using Renci.SshNet;
using ServerReservation.Data;
using ServerReservation.Models;

namespace ServerReservation.Controllers
{
    [Authorize]
    public class ServerController : Controller
    {
        private readonly ApplicationDbContext _context;

        private SshClient client;
        private static string username = "username";// TODO: Enter your sftp username here
        private static string password = "password";// TODO: Enter your sftp password here

        public ServerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Server
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servers.ToListAsync());
        }

        // GET: Select
        public async Task<IActionResult> Select()
        {
            return View(await _context.Servers.ToListAsync());
        }

        // GET: Server/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // GET: Server/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Server/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Server server)
        {
            if (ModelState.IsValid)
            {
                _context.Add(server);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: Server/CreateRequest
        public IActionResult CreateRequest()
        {
            return View();
        }

        // POST: Server/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequest(Server server)
        {
            if (ModelState.IsValid)
            {
                _context.Add(server);
                await _context.SaveChangesAsync();

                return RedirectToAction("Create", "Request", new { id = server.Id });
            }
            return View(server);
        }

        // GET: Server/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return View(server);
        }

        // POST: Server/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Server server)
        {
            if (id != server.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(server);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerExists(server.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: Server/Edit/5
        public async Task<IActionResult> EditRequest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return View(server);

        }

        // POST: Server/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRequest(int id, Server server)
        {
            if (id != server.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(server);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerExists(server.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Create", "Request", new { id = server.Id });
            }
            return View(server);
        }

        // GET: Server/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // POST: Server/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var server = await _context.Servers.FindAsync(id);
            _context.Servers.Remove(server);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerExists(int id)
        {
            return _context.Servers.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Download(string IPv4Address)
        {
            if (string.IsNullOrEmpty(IPv4Address))
            {
                return NotFound();
            }

            Response.Headers.Add("Content-Disposition", "attachment; filename=Default.rdp");
            return new FileContentResult(Encoding.UTF8.GetBytes("full address:s:" + IPv4Address), "text/rdp");
        }


        public void SSH(string host)
        {
            string fileName = "install.bat";//TODO: "install.bat" is the name of the file which should be located in your project root directory.

            UploadFile(host, fileName);
            ExecuteCommandAsync(host);
        }

        private void UploadFile(string host, string fileName)
        {
            var connectionInfo = new ConnectionInfo(host, "sftp", new PasswordAuthenticationMethod(username, password));
            // Upload File
            using (var sftp = new SftpClient(connectionInfo))
            {
                sftp.Connect();
                sftp.ChangeDirectory("/MyFolder");//TODO: Change Directory
                using (var uplfileStream = System.IO.File.OpenRead(fileName))
                {
                    sftp.UploadFile(uplfileStream, fileName, true);
                }
                sftp.Disconnect();
            }
        }

        private void ExecuteCommandAsync(string host)
        {

            using (var client = new SshClient(host, username, password))
            {
                #region SshCommand RunCommand Result
                client.Connect();

                var command = client.RunCommand("install.bat");//TODO: Customize command
                var result = command.Result;

                client.Disconnect();
                #endregion


            }
        }

    }
}


