using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LendingGame.Application.ViewModels
{

    public class LoanViewModel
    {
        public LoanViewModel()
        {
            Games = new List<GameViewModel>();
            Friends = new List<FriendViewModel>();
        }

        [Display(Name = "Código")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Amigo")]
        public string FriendId { get; set; }

        [Required]
        [Display(Name = "Jogo")]
        public string GameId { get; set; }

        [IgnoreDataMember]
        public bool IsBorrowed { get; set; }

        [Required]
        [Display(Name = "Data de empréstimo")]
        public DateTime LoanDate { get; set; }
        

        [Display(Name = "Data de devolução")]
        
        public DateTime? ReturnDate { get; set; }

        public virtual GameViewModel BorrowedGame { get; set; }
        public virtual FriendViewModel Friend { get; set; }

        public IEnumerable<GameViewModel> Games;
        public IEnumerable<FriendViewModel> Friends;
    }
}