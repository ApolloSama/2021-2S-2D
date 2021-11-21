import { Component } from 'react';
import './App.css';

class GitUser extends Component {

  constructor(props) {
    super(props);
    this.state = {
      listaRepositories: [],
      repoName: ''
    }
  }

  BuscarRepositorio = (elemento) => {
    elemento.preventDefault();

    console.log("Buscando repositório")

    fetch(`https://api.github.com/users/${this.state.repoName}/repos?per_page=10&sort=author-date-desc`)

      .then(resposta => resposta.json())

      .then(lista => this.setState({ listaRepositories: lista }))

      .catch(erro => console.log(erro))
  }

  AtualizarNome = async (nome) => {
    await this.setState({ repoName: nome.target.value })
    console.log(this.state.repoName)
  }

  render() {
    return (
      <div>
        <main>

          <section>
            <h2>Buscar repositórios do Github</h2>
            <form onSubmit={this.BuscarRepositorio}>
              <input type="text" value={this.state.repoName} onChange={this.updateName} placeholder="Usuario do Github"/>
              <button type="submit" onClick={this.BuscarRepositorio}>Buscar</button>
            </form>
          </section>

          <section>

            <table>
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Nome</th>
                  <th>Descrição</th>
                  <th>Data De Criação</th>
                  <th>Tamanho</th>
                </tr>
              </thead>

              <tbody>
                {this.state.listaRepositories.map((r) => {
                  return (
                    <tr key={r.id}>
                      <td>{r.id}</td>
                      <td>{r.name}</td>
                      <td>{r.description}</td>
                      <td>{r.created_at}</td>
                      <td>{r.size}</td>
                    </tr>
                  )
                })}
              </tbody>
              
            </table>

          </section>

        </main>
      </div>
    )
  }
}

export default GitUser;