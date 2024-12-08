"use client";

import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { useState } from "react";

// Tipos para as colunas e linhas
type Column = {
  id: string;
  label: string;
  align?: "left" | "right" | "center";
};

type RowData = {
  [key: string]: string | number | string[] | number[]; // Dados que podem ser numéricos ou textos
  history: { date: string; customerId: string; amount: number }[];
};

interface CollapsibleTableProps {
  columns: Column[];
  rows: RowData[];
  onEdit: (row: RowData) => void; // Função para editar
  onDelete: (row: RowData) => void; 
  onClick: () => void
}

// Função para criar a linha
function Row(props: {
  row: RowData;
  columns: Column[];
  onEdit: any;
  onDelete: any;
}) {
  const { row, columns, onEdit, onDelete } = props;
  const [open, setOpen] = useState<boolean>(false);

  return (
    <>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        {/* Colunas da tabela */}
        {columns.map((column, index) => (
          <TableCell key={index} align={column.align || "left"}>
            {row[column.id]}
          </TableCell>
        ))}

        {/* Ícones de dropdown, editar e excluir na última célula (coluna final) */}
        <TableCell align="right">
          <Box sx={{ display: "flex", justifyContent: "flex-end", gap: 1 }}>
            {/* Ícone de dropdown à direita */}

            {/* Botões de editar e excluir */}
            <IconButton
              aria-label="edit"
              size="small"
              onClick={() => onEdit(row)} // Chama a função de edição
            >
              <EditIcon />
            </IconButton>
            <IconButton
              aria-label="delete"
              size="small"
              onClick={() => onDelete(row)} // Chama a função de exclusão
            >
              <DeleteIcon />
            </IconButton>
            <IconButton
              aria-label="expand row"
              size="small"
              onClick={() => setOpen(!open)}
            >
              {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
            </IconButton>
          </Box>
        </TableCell>
      </TableRow>

      {/* Detalhes colapsáveis */}
      <TableRow>
        <TableCell
          style={{ paddingBottom: 0, paddingTop: 0 }}
          colSpan={columns.length + 1}
        >
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                History
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>Customer</TableCell>
                    <TableCell align="right">Amount</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.history.map((historyRow) => (
                    <TableRow key={historyRow.date}>
                      <TableCell component="th" scope="row">
                        {historyRow.date}
                      </TableCell>
                      <TableCell>{historyRow.customerId}</TableCell>
                      <TableCell align="right">{historyRow.amount}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </>
  );
}

// Componente da Tabela Colapsável
const CollapsibleTable = ({
  columns,
  rows,
  onEdit,
  onDelete,
  onClick,
}: CollapsibleTableProps) => {
  return (
    <TableContainer component={Paper}>
      <div className="flex justify-end gap-8 h-10 my-6 px-5">
        <input className="w-1/4 bg-background rounded-xl"></input>
        <button className="bg-foreground text-background rounded-xl " onClick={onClick}>
          Cadastrar produto
        </button>
      </div>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            {/* Cabeçalhos de colunas */}
            {columns.map((column) => (
              <TableCell key={column.id} align={column.align}>
                {column.label}
              </TableCell>
            ))}
            {/* Coluna adicional para os ícones à direita */}
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row, index) => (
            <Row
              key={index}
              row={row}
              columns={columns}
              onEdit={onEdit}
              onDelete={onDelete}
            />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default CollapsibleTable;
