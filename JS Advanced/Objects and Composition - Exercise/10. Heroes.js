function main() {

    let guild = {

        fighter: function (name) {

            let fighterr = {

                name,
                health: 100,
                stamina: 100,

                fight() {

                    this.stamina--;
                    console.log(`${name} slashes at the foe!`);
                }
            }
            return fighterr;
        },

        mage: function (name) {

            let magee = {

                name,
                health: 100,
                mana: 100,

                cast(spell) {

                    this.mana--;
                    console.log(`${name} cast ${spell}`)
                }
            }
            return magee;

        }

    }

    return guild;
}

let create = main();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
