function factory(car){
    const engines = {
        small: { power: 90, volume: 1800 },
        normal: { power: 120, volume: 2400 },
        monster: { power: 200, volume: 3500 },
    }

    return {
        model: car.model,
        engine: car.power <= 90 ? engines.small : car.power <= 120 ? engines.normal : engines.monster, // you can loop with Object entries and use engines[engine name] to select
        carriage: {type: car.carriage, color: car.color},
        wheels: parseInt(car.wheelsize) % 2 == 0 ? (Array(4).fill(car.wheelsize-1)) : (Array(4).fill(car.wheelsize)) 
    }
}

console.log(factory({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 17 }));
console.log(17%2==0);