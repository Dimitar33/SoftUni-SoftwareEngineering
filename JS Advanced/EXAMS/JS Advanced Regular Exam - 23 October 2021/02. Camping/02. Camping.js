class SummerCamp {

    constructor(organizer, location) {

        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { child: 150, student: 300, collegian: 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {

        if (!this.priceForTheCamp.hasOwnProperty(condition)) {

            throw new Error(`Unsuccessful registration at the camp.`);
        }

        let member = this.listOfParticipants.find(x => x.name == name);

        if (member) {

            return `The ${name} is already registered at the camp.`
        }

        if (this.priceForTheCamp[condition] > money) {

            return `The money is not enough to pay the stay at the camp.`
        }

        member = { name, condition, power: 100, wins: 0 };

        this.listOfParticipants.push(member);

        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name) {

        let member = this.listOfParticipants.find(x => x.name == name);

        if (!member) {

            throw new Error(`The ${name} is not registered in the camp.`)
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x.name != name);

        return `The ${name} removed successfully.`
    }

    timeToPlay(typeOfGame, participant1, participant2) {

        let member1 = this.listOfParticipants.find(x => x.name == participant1);
        let member2 = this.listOfParticipants.find(x => x.name == participant2);

        if (typeOfGame == `Battleship`) {

            if (!member1) {
                
                throw new Error(`Invalid entered name.`);
            }

            member1.power += Number(20);

            return `The ${member1.name} successfully completed the game ${typeOfGame}.`;
        }
        
        if (typeOfGame == `WaterBalloonFights`) {

            if (!member1 || !member2) {
                
                if (!member1 && !member2) {
                
                    throw new Error(`Invalid entered names.`);
                }
    
                throw new Error(`Invalid entered name.`);
            }

            if (member1.condition != member2.condition) {

                throw new Error(`Choose players with equal condition.`)
            }
    

            if (member1.power > member2.power) {

                member1.wins++;
                return `The ${member1.name} is winner in the game ${typeOfGame}.`;
            }

            if (member1.power < member2.power) {

                member2.wins++;
                return `The ${member2.name} is winner in the game ${typeOfGame}.`;
            }

            return `There is no winner.`
        }
    }

    toString () {

        let result = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        this.listOfParticipants
        .sort((a,b) => b.wins - a.wins)
        .forEach(player => {
            
            result += `${player.name} - ${player.condition} - ${player.power} - ${player.wins}\n`;
        });

        return result.trimEnd();
    }
}
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.unregisterParticipant("Petar Petarson"));
console.log(summerCamp.unregisterParticipant("Petar"));
