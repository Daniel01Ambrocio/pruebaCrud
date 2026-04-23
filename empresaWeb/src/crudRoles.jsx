import { useEffect, useState, Fragment } from "react";
import Table from "react-bootstrap/Table";
import "bootstrap/dist/css/bootstrap.min.css";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Col from "react-bootstrap/Col";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const CrudRoles = () => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  //variables de estado para nuevos registros
  const [nombrerol, setNombreRol] = useState("");
  const [permisoget, setPermisoGet] = useState(0);
  const [permisoPost, setPermisoPost] = useState(0);
  const [permisoPut, setPermisoPut] = useState(0);
  const [permisoDelete, setPermisoDelete] = useState(0);

  //variables de estado para actualizar un registro
  const [editIdRol, setEditIdRol] = useState(0);
  const [editNombrerol, setEditNombreRol] = useState("");
  const [editPermisoget, setEditPermisoGet] = useState(0);
  const [editPermisoPost, setEditPermisoPost] = useState(0);
  const [editPermisoPut, setEditPermisoPut] = useState(0);
  const [editPermisoDelete, setEditPermisoDelete] = useState(0);

  const [roles, setRoles] = useState([]);

  useEffect(() => {
    getRoles();
  }, []);

  const getRoles = () => {
    axios
      .get("https://localhost:44377/api/Roles")
      .then((result) => {
        setRoles(result.data);
      })
      .catch((error) => {
        //Manejador de errores
        console.log(error);
      });
  };
  const handleEdit = (item) => {
    setEditIdRol(item.IdRol);
    setEditNombreRol(item.NombreRol);
    setEditPermisoGet(item.PermisoGet);
    setEditPermisoPost(item.PermisoPOST);
    setEditPermisoPut(item.PermisoPUT);
    setEditPermisoDelete(item.PermisoDelete);
    handleShow();
  };
  const handleDelete = (idRol) => {
    if (window.confirm("¿Está segur@ de querer eliminar el rol?")) {
      axios
        .delete(`https://localhost:44377/api/Roles/${idRol}`)
        .then((result) => {
          getRoles();
          toast.success("Rol eliminado correctamente");
        })
        .catch((error) => {
          console.log(error);
        });
    }
  };
  const handleSave = () => {
    const url = "https://localhost:44377/api/Roles";
    const data = {
      NombreRol: nombrerol,
      PermisoGet: permisoget,
      PermisoPOST: permisoPost,
      PermisoPUT: permisoPut,
      PermisoDelete: permisoDelete,
    };
    axios
      .post(url, data)
      .then((result) => {
        getRoles();
        clear();
        toast.success("Rol registrado correctamente");
      })
      .catch((error) => {
        //Manejador de errores
        console.log(error);
      });
  };

  const clear = () => {
    setNombreRol("");
    setPermisoGet(0);
    setPermisoPost(0);
    setPermisoPut(0);
    setPermisoDelete(0);
    setEditNombreRol("");
    setEditPermisoGet(0);
    setEditPermisoPost(0);
    setEditPermisoPut(0);
    setEditPermisoDelete(0);
  };

  const handleUpdate = () => {
    const url = `https://localhost:44377/api/Roles/${editIdRol}`;

    const data = {
      IdRol: editIdRol,
      NombreRol: editNombrerol,
      PermisoGet: editPermisoget,
      PermisoPOST: editPermisoPost,
      PermisoPUT: editPermisoPut,
      PermisoDelete: editPermisoDelete,
    };

    axios
      .put(url, data)
      .then((result) => {
        getRoles();
        handleClose();
        clear();
        toast.success("Rol actualizado correctamente");
      })
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <Fragment>
      <ToastContainer />
      <Container>
        <Row>
          <Col>
            <input
              type="text"
              className="form-control"
              placeholder="Ingrese el nombre del rol"
              value={nombrerol}
              onChange={(e) => {
                setNombreRol(e.target.value);
              }}
            />
          </Col>
          <Col>
            <input
              type="checkbox"
              checked={permisoget === 1}
              onChange={(e) => setPermisoGet(e.target.checked ? 1 : 0)}
            />
            <label>Permisos Ver</label>
          </Col>
          <Col>
            <input
              type="checkbox"
              onChange={(e) => setPermisoPut(e.target.checked ? 1 : 0)}
              value={permisoPut}
            />
            <label>Permisos Actualizar</label>
          </Col>
          <Col>
            <input
              type="checkbox"
              onChange={(e) => setPermisoPost(e.target.checked ? 1 : 0)}
              value={permisoPost}
            />
            <label>Permisos Insertar</label>
          </Col>
          <Col>
            <input
              type="checkbox"
              onChange={(e) => setPermisoDelete(e.target.checked ? 1 : 0)}
              value={permisoDelete}
            />
            <label>Permisos Eliminar</label>
          </Col>
          <Col>
            <button
              className="btn btn-primary"
              onClick={() => {
                handleSave();
              }}
            >
              Registrar
            </button>
          </Col>
        </Row>
      </Container>
      <br />
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Nombre rol</th>
            <th>Permiso Get</th>
            <th>Permisos Post</th>
            <th>Permisos Put</th>
            <th>Permisos Delete</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {roles && roles.length > 0
            ? roles.map((item, index) => {
                return (
                  <tr key={index}>
                    <td>{index + 1}</td>
                    <td>{item.NombreRol}</td>
                    <td>{item.PermisoGet}</td>
                    <td>{item.PermisoPOST}</td>
                    <td>{item.PermisoPUT}</td>
                    <td>{item.PermisoDelete}</td>
                    <td colSpan={2}>
                      <button
                        className="btn btn-primary"
                        onClick={() => handleDelete(item.IdRol)}
                      >
                        Editar
                      </button>{" "}
                      &nbsp;
                      <button
                        className="btn btn-danger"
                        onClick={() => {
                          hanldeDelete(item.index);
                        }}
                      >
                        Eliminar
                      </button>
                    </td>
                  </tr>
                );
              })
            : "Cargando..."}
        </tbody>
      </Table>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Actualiza Rol</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Row>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Ingrese el nombre del rol"
                value={editNombrerol}
                onChange={(e) => {
                  setEditNombreRol(e.target.value);
                }}
              />
            </Col>
            <Col>
              <input
                type="checkbox"
                checked={editPermisoget === 1 ? true : false}
                onChange={(e) => setEditPermisoGet(e.target.checked ? 1 : 0)}
                value={editPermisoget}
              />
              <label>Permisos Ver</label>
            </Col>
            <Col>
              <input
                type="checkbox"
                checked={editPermisoPut === 1 ? true : false}
                onChange={(e) => setEditPermisoPut(e.target.checked ? 1 : 0)}
                value={editPermisoPut}
              />
              <label>Permisos Actualizar</label>
            </Col>
            <Col>
              <input
                type="checkbox"
                checked={editPermisoPost === 1 ? true : false}
                onChange={(e) => setEditPermisoPost(e.target.checked ? 1 : 0)}
                value={editPermisoPost}
              />
              <label>Permisos Insertar</label>
            </Col>
            <Col>
              <input
                type="checkbox"
                checked={editPermisoDelete === 1 ? true : false}
                onChange={(e) => setEditPermisoDelete(e.target.checked ? 1 : 0)}
                value={editPermisoDelete}
              />
              <label>Permisos Eliminar</label>
            </Col>
          </Row>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Cerrar
          </Button>
          <Button variant="primary" onClick={handleUpdate}>
            Guardar cambios
          </Button>
        </Modal.Footer>
      </Modal>
    </Fragment>
  );
};

export default CrudRoles;
