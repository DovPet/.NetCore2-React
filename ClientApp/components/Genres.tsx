import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";

interface FetchGenresDataState {
  genres: Genre[];
  loading: boolean;
}
export class Genres extends React.Component<
  RouteComponentProps<{}>,
  FetchGenresDataState
> {
  constructor(props) {
    super(props);
    this.state = { genres: [], loading: true };
    fetch("api/genres")
      .then(response => response.json() as Promise<Genre[]>)
      .then(data => {
        this.setState({ genres: data, loading: false });
      });
    // This binding is necessary to make "this" work in the callback
    this.handleDelete = this.handleDelete.bind(this);
    this.handleEdit = this.handleEdit.bind(this);
  }
  public render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderGenresTable(this.state.genres)
    );
    return (
      <div>
        <h1>Genres Data</h1>
        <p>This component demonstrates fetching Genres data from the server.</p>
        <p>
          <Link to="/genre/new">Create New</Link>
        </p>
        {contents}
      </div>
    );
  }

  private handleDelete(id: number) {
    if (!confirm("Do you want to delete genre with Id: " + id)) return;
    else {
      fetch("api/genres/" + id, {
        method: "DELETE"
      }).then(data => {
        this.setState({
          genres: this.state.genres.filter(rec => {
            return rec.id != id;
          })
        });
      });
    }
  }
  private handleEdit(id: number) {
    this.props.history.push("/genre/edit/" + id);
  }
  // Returns the HTML table to the render() method.
  private renderGenresTable(genres: Genre[]) {
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
          {genres.map(emp => (
            <tr key={emp.id}>
              <td />
              <td>{emp.id}</td>
              <td>{emp.name}</td>
              <td>
                <a className="action" onClick={id => this.handleEdit(emp.id)}>
                  <span className="glyphicon glyphicon-edit"> </span>{" "}
                </a>|
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
export class Genre {
  id: number = 0;
  name: string = "";
  description: string = "";
}
