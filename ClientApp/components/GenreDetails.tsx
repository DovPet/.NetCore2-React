import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";
import { Genre } from "./Genres";
interface GenreDetailsState {
  title: string;
  loading: boolean;
  genre: Genre;
}
export class GenreDetails extends React.Component<
  RouteComponentProps<{}>,
  GenreDetailsState
> {
  constructor(props) {
    super(props);
    this.state = {
      title: "",
      loading: true,
      genre: new Genre()
    };

    var id = this.props.match.params["id"];
    // This will set state for Edit genre

    fetch("api/genres/" + id)
      .then(response => response.json() as Promise<Genre>)
      .then(data => {
        this.setState({ title: "Details", loading: false, genre: data });
      });

    // This will set state for Add genre

    // This binding is necessary to make "this" work in the callback
    this.handleCancel = this.handleCancel.bind(this);
  }
  public render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderCreateForm()
    );
    return (
      <div>
        <h1>{this.state.title}</h1>
        <h3>Genre</h3>
        <hr />
        {contents}
      </div>
    );
  }

  // This will handle the submit form event.

  // This will handle Cancel button click event.
  private handleCancel(e) {
    e.preventDefault();
    this.props.history.push("/genres");
  }
  // Returns the HTML Form to the render() method.
  private renderCreateForm() {
    return (
      <div>
        <h2>Information</h2>
        <ul>
          <li>Name: {this.state.genre.name}</li>
        </ul>
        <ul>
          <li>Description: {this.state.genre.description} </li>
        </ul>
        <br />
        <button className="btn" onClick={this.handleCancel}>
          Back
        </button>
      </div>
    );
  }
}
