function sorter(array, orderby){
    if(orderby==='asc')
    return array.sort((a,b) => a-b);
    else if(orderby==='desc')
    return array.sort((a,b) => b-a);
}

console.log(sorter([14, 7, 17, 6, 8], 'desc'));