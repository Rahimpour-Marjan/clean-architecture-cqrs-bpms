import { useForm } from 'react-hook-form';
import { Button, Input } from '../../components';
import { Form } from '../../components/Form';
import { FormRow } from '../../components/FormRow';
import { Select } from '../../components/Select';
import { Textarea } from '../../components/Textarea';
import { useCategories } from '../../hooks/useCategories';
import { useCreatePost } from '../../hooks/useCreatePost';
import { useEditPost } from '../../hooks/useEditPost';

export const CreateEditPostForm = ({ post = {} }) => {
  const { categories } = useCategories();
  const { createPost, isCreating } = useCreatePost();
  const { editPost, isEditing } = useEditPost();
  const { postId, ...editingPost } = post;

  const isEditingSession = Boolean(postId);

  const {
    register,
    handleSubmit,
    formState: { isDirty, isValid, errors },
  } = useForm({
    mode: 'all',
    defaultValues: isEditingSession ? editingPost : {},
  });

  const canSubmit = !(isDirty && isValid);

  const onSubmit = data => {
    if (isEditingSession) {
      editPost(data);
    } else {
      createPost(data, {
        onSuccess: () => {},
      });
    }
  };

  const isDisabled = isCreating || isEditing;

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <FormRow error={errors?.name?.message}>
        <Input
          type='text'
          {...register('name', {
            required: 'This field is required',
          })}
          placeholder='Name'
          hasError={!!errors?.name?.message}
          disabled={isDisabled}
        />
      </FormRow>

      <FormRow error={errors?.description?.message}>
        <Textarea
          label='description'
          register={register}
          placeholder='Description'
          hasError={!!errors?.description?.message}
          disabled={isDisabled}
        />
      </FormRow>

      <FormRow error={errors?.category?.message}>
        <Select
          options={categories?.map(category => ({
            label: category.name,
            value: category.id,
          }))}
          register={register}
          label='category'
          placeholder='Category'
          hasError={!!errors?.category?.message}
          disabled={isDisabled}
        />
      </FormRow>

      <FormRow>
        <Button
          type='submit'
          variation='primary'
          disabled={canSubmit || isDisabled}
        >
          {isEditing ? 'Edit' : 'Create'}
        </Button>
      </FormRow>
    </Form>
  );
};
