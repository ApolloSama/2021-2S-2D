import React from 'react';
import './App.css';

function DataFormatada(props) {
  return <h2>Horário Atual: {props.date.toLocaleTimeString()}</h2>
}


class Clock extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      date: new Date()
    };
  };


  tick() {
    this.setState({
      date: new Date()
    })
  };


  pausar() {
    this.componentWillUnmount()
    console.log(`Relogio ${this.timerID} pausado.`)
  };

  rodar() {
    this.timerID = setInterval(() => {
      this.tick()
    }, 1000)
    console.log('Relógio retomado!')
  }



  
  componentDidMount() {
    this.timerID = setInterval(() => {
      this.tick()
    }, 1000);

  
    console.log('Agora eu sou o relógio ' + this.timerID);
  };


  componentWillUnmount() {
    clearInterval(this.timerID);
  };




  
  render() {
    return (
      <div>
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date} />
        <button onClick={() => this.pausar()}>Pausar</button>
        <button onClick={() => this.rodar()}>Retomar</button>
      </div>
    )
  }

}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

export default App;
