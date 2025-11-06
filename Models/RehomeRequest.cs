using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurByte.Models;

/// <summary>
/// Represents the status of a rehoming request.
/// </summary>
/// <remarks>This enumeration is used to indicate the current state of a rehoming process.</remarks>
public enum RehomeStatus
{
	Pending,
	Approved,
	Rejected
}

/// <summary>
/// Represents a request to rehome a pet, including details about the current and new owners, the pet being rehomed, and
/// the status of the request.
/// </summary>
/// <remarks>This class is used to manage the process of transferring a pet from its current owner to a new owner.
/// It includes information about the pet, the reason for rehoming, and the current status of the request.</remarks>
public class RehomeRequest
{
	// primary key 
	[Key]
	public int RehomeRequestId { get; set; }

	// pet name being rehomed 
	[Required]
	public required string PetName { get; set; }

	// the pets current owner 
	[Required]
	public required string OwnerId { get; set; }
	[Required]
	// explicit FK navigation to ApplicationUser
	[ForeignKey("OwnerId")]
	public required ApplicationUser Owner { get; set; }

	// new owner taking the pet in
	[Required]
	[ForeignKey("NewOwnerId")]
	public required string NewOwnerId { get; set; }
	[Required]
	public required ApplicationUser NewOwner { get; set; }

	// the reason the current owner is rehoming the pet
	// description field 
	[Required]
	public required string ReasonForRehome { get; set; }
	// ----------------------------Separator---------------------------------

	// created a custom RehomeStatus called status that 
	// allows our Overseers to approve or reject rehome requests, 
	// and the users to view the status of their requests.
	[Required]
	public required RehomeStatus Status { get; set; } = RehomeStatus.Pending;

	// the different statuses for the rehome request
	// enum = enumeration, this enumeration defines a set of named constants

}
