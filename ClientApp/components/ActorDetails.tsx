import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";
import { Actor } from "./Actors";
interface ActorDetailsState {
  title: string;
  loading: boolean;
  actor: Actor;
}
export class ActorDetails extends React.Component<
  RouteComponentProps<{}>,
  ActorDetailsState
> {
  constructor(props) {
    super(props);
    this.state = {
      title: "",
      loading: true,
      actor: new Actor()
    };

    var id = this.props.match.params["id"];
    // This will set state for Edit actor

    fetch("api/actors/" + id)
      .then(response => response.json() as Promise<Actor>)
      .then(data => {
        this.setState({ title: "Details", loading: false, actor: data });
      });

    // This will set state for Add actor

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
        <h3>Actor</h3>
        <hr />
        {contents}
      </div>
    );
  }

  // This will handle the submit form event.

  // This will handle Cancel button click event.
  private handleCancel(e) {
    e.preventDefault();
    this.props.history.push("/actors");
  }
  // Returns the HTML Form to the render() method.
  private renderCreateForm() {
    return (
      <div>
        <h2>Information</h2>
        <ul>
          <li>First Name: {this.state.actor.firstName}</li>
        </ul>
        <ul>
          <li>Last Name: {this.state.actor.lastName}</li>
        </ul>
        <ul>
          <li>Description: {this.state.actor.description} </li>
        </ul>
        <br />
        <button className="btn" onClick={this.handleCancel}>
          Back
        </button>
      </div>
    );
  }
}
