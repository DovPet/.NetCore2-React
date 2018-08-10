import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";

interface FetchActorsDataState {
  actors: Actor[];
  loading: boolean;
}
export class Actors extends React.Component<
  RouteComponentProps<{}>,
  FetchActorsDataState
> {
  constructor(props) {
    super(props);
    this.state = { actors: [], loading: true };
    fetch("api/actors")
      .then(response => response.json() as Promise<Actor[]>)
      .then(data => {
        this.setState({ actors: data, loading: false });
      });
    // This binding is necessary to make "this" work in the callback
    this.handleDelete = this.handleDelete.bind(this);
    this.handleEdit = this.handleEdit.bind(this);
    this.handleDetails = this.handleDetails.bind(this);
  }
  public render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderActorsTable(this.state.actors)
    );
    return (
      <div>
        <h1>Actors Data</h1>
        <p>This component demonstrates fetching Actors data from the server.</p>
        <p>
          <Link to="/actor/new">Create New</Link>
        </p>
        {contents}
      </div>
    );
  }

  private handleDelete(id: number) {
    if (!confirm("Do you want to delete actor with Id: " + id)) return;
    else {
      fetch("api/actors/" + id, {
        method: "DELETE"
      }).then(data => {
        this.setState({
          actors: this.state.actors.filter(rec => {
            return rec.id != id;
          })
        });
      });
    }
  }
  private handleDetails(id: number) {
    this.props.history.push("/actor/details/" + id);
  }
  private handleEdit(id: number) {
    this.props.history.push("/actor/edit/" + id);
  }
  // Returns the HTML table to the render() method.
  private renderActorsTable(actors: Actor[]) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th />
            <th>Id</th>
            <th>Name</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {actors.map(emp => (
            <tr key={emp.id}>
              <td />
              <td onClick={id => this.handleDetails(emp.id)}>{emp.id}</td>
              <td onClick={id => this.handleDetails(emp.id)}>{emp.fullName}</td>
              <td>
                <a className="action" onClick={id => this.handleEdit(emp.id)}>
                  <span className="glyphicon glyphicon-edit"> </span>{" "}
                </a>
                |
                <a className="action" onClick={id => this.handleDelete(emp.id)}>
                  <span className="glyphicon glyphicon-remove"> </span>{" "}
                </a>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}
export class Actor {
  id: number = 0;
  fullName: string = "";
  firstName: string = "";
  lastName: string = "";
  description: string = "";
}
