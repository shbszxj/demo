using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Example.Member.Models
{
    /// <summary>
    /// Request to register a member
    /// </summary>
    public class RegisterMemberRequest
    {
        /// <summary>
        /// Username of member
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of member
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Email of member
        /// </summary>
        public string Email { get; set; }
    }
}
