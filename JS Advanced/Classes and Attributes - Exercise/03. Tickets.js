function sortTickets(arr, sortTerm) {

    let tickets = [];

    class Ticket {

        constructor(destination, price, status) {

            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    arr.forEach(el => {

        let [dest, pr, st] = el.split(`|`);
        pr = Number(pr);

        let ticket = new Ticket(dest, pr, st);

        tickets.push(ticket);
    });

    switch (sortTerm) {

        case `destination`:

            tickets.sort((a, b) => (a.destination.localeCompare(b.destination)));

            break;

        case `price`:

            tickets.sort((a, b) => a.price - b.price);

            break;

        case `status`:

            tickets.sort((a, b) => (a.status.localeCompare(b.status)));

            break;
        default:
            break;
    }

    return tickets;
}

sortTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination')
