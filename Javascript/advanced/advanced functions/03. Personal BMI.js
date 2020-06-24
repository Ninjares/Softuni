function bmi(name, age, weight, height){
    let patient = {};
    patient.name = name;
    patient.personalInfo = {
        age: age,
        weight: weight,
        height: height
    }
    let bodymassindex = weight / ((height/100)**2);
    patient.BMI = Math.round(bodymassindex);
    if(bodymassindex<18.5){
        patient.status = 'underweight';
    }
    else if(bodymassindex>=18.5&&bodymassindex<25){
        patient.status = 'normal';
    }
    else if(bodymassindex>=25&&bodymassindex<30){
        patient.status = 'overweight';
    }
    else if(bodymassindex>=30){
        patient.status = 'obese';
        patient.recommendation = 'admission required';
    }
    return patient;
}

console.log(bmi('Peter', 29, 75, 182));