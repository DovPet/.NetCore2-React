import * as React from "react";
import { Link, NavLink } from "react-router-dom";

export class NavMenu extends React.Component<{}, {}> {
  public render() {
    return (
      <div className="main-nav">
        <div className="navbar navbar-inverse">
          <div className="navbar-header">
            <button
              type="button"
              className="navbar-toggle"
              data-toggle="collapse"
              data-target=".navbar-collapse"
            >
              <span className="sr-only">Toggle navigation</span>
              <span className="icon-bar" />
              <span className="icon-bar" />
              <span className="icon-bar" />
            </button>
            <Link className="navbar-brand" to={"/"}>
              my_new_app
            </Link>
          </div>
          <div className="clearfix" />
          <div className="navbar-collapse collapse">
            <ul className="nav navbar-nav">
              <li>
                <NavLink to={"/"} exact activeClassName="active">
                  <span className="glyphicon glyphicon-home" /> Home
                </NavLink>
              </li>
              <li>
                <NavLink to={"/counter"} activeClassName="active">
                  <span className="glyphicon glyphicon-education" /> Counter
                </NavLink>
              </li>
              <li>
                <NavLink to={"/fetchdata"} activeClassName="active">
                  <span className="glyphicon glyphicon-th-list" /> Fetch data
                </NavLink>
              </li>
              <li>
                <NavLink to={"/genres"} activeClassName="active">
                  <span className="glyphicon glyphicon-th-list" /> Genres
                </NavLink>
              </li>
              <li>
                <NavLink to={"/actors"} activeClassName="active">
                  <span className="glyphicon glyphicon-th-list" /> Actors
                </NavLink>
              </li>
            </ul>
          </div>
        </div>
      </div>
    );
  }
}
