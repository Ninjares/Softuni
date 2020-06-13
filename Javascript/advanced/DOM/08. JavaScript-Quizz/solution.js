function solve() {
  let rightanswers = 0;
  let currentsection = 0;
  for(let answer of document.querySelectorAll('.quiz-answer')){
      answer.addEventListener('click', function(){
          if(answer.innerText == 'onclick' || answer.innerText == 'JSON.stringify()' || answer.innerText == 'A programming API for HTML and XML documents')  rightanswers++;
          nextQuestion(); 
      });
  }
  
  function nextQuestion(){
    document.getElementsByTagName('section')[currentsection].style['display'] = 'none';
    document.getElementsByTagName('section')[currentsection].className = '';
    currentsection++;
    if(document.getElementsByTagName('section').length <= currentsection){
      if(rightanswers == 3){
        document.getElementsByTagName('h1')[1].innerText = 'You are recognized as top JavaScript fan!';
      }
      else document.getElementsByTagName('h1')[1].innerText = 'You have '+rightanswers+' right answers';
      document.getElementById('results').style['display'] = 'block';
    }
    else document.getElementsByTagName('section')[currentsection].style['display'] = 'block';
  }
}
