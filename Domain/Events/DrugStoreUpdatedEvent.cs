using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Events;

public class DrugStoreUpdatedEvent : IDomainEvent
{
    public DrugStoreUpdatedEvent(Guid id, string oldDrugNetwork, string newDrugNetwork, int oldNumber, int newNumber,
        Address oldAddress, Address newAddress)
    {
        OldDrugNetwork = oldDrugNetwork;
        NewDrugNetwork = newDrugNetwork;
        OldNumber = oldNumber;
        NewNumber = newNumber;
        OldAddress = oldAddress;
        NewAddress = newAddress;
        UpdatedAt = DateTime.Now;
    }

    private Guid Id { get; }
    private string OldDrugNetwork { get; }
    private string NewDrugNetwork { get; }
    private int OldNumber { get; }
    private int NewNumber { get; }
    private Address OldAddress { get; }
    private Address NewAddress { get; }
    public DateTime UpdatedAt { get; }
}