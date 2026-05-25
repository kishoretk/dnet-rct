import { Typography, List, ListItem, ListItemText, CssBaseline, Container, Grid } from "@mui/material";
import TaskItemList from "./TaskItemList";
import TaskDetail from "../details/TaskDetail";
import { TaskItemForm } from "../form/TaskItemForm";

type Props = {
    taskitems: TaskItem[]
    selectedTaskItem: TaskItem | null | undefined
    selectTaskItem: (id: string) => void
    cancelTaskItem: () => void
    openForm: (id?: string) => void
    closeForm: () => void
    editMode: boolean
}

export default function TaskItemDashboard({ taskitems, selectedTaskItem, selectTaskItem, cancelTaskItem, openForm, closeForm, editMode }: Props) {
    return (
        <>
            <Grid container spacing={2}>
                <Grid size={8}>
                    <TaskItemList taskitems={taskitems} selectTaskItem={selectTaskItem} />
                </Grid>
                <Grid size={4}>
                    {selectedTaskItem && !editMode &&
                        <TaskDetail taskitem={selectedTaskItem}
                            cancelTaskItem={cancelTaskItem}
                            openForm={() => openForm(selectedTaskItem.id)}
                            closeForm={closeForm}
                        />}


                    {editMode && <TaskItemForm closeForm={closeForm} taskitem={selectedTaskItem} />}
                </Grid>
            </Grid>
        </>
    )
}
